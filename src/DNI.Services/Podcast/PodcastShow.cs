﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DNI.Services.Podcast {
    /// <summary>
    ///     Represents a single podcast
    /// </summary>
    public class PodcastShow {
        private readonly Regex podcastUriVersionMatcher =
            new Regex(@"/v(\d+-\d+)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        private readonly Regex podcastUriSlugMatcher =
            new Regex(@"/([^/\s]+)$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string PageUrl { get; set; }

        public string Content { get; set; }

        public string ContentHtml { get; set; }

        public string Summary { get; set; }

        public DateTime PublishedTime { get; set; }

        public PodcastFile AudioFile { get; set; }

        public string HeaderImage { get; set; }

        public IEnumerable<string> Keywords { get; set; }

        /// <summary>
        ///     Returns the version of the <see cref="PageUrl" />, or null if the <see cref="PageUrl" /> is not version compatible.
        /// </summary>
        public decimal? Version {
            get {
                var m = podcastUriVersionMatcher.Match(PageUrl);
                if(!m.Success) {
                    return null;
                }

                var version = m.Groups[1].Value.Replace("-", ".").Trim();

                if(decimal.TryParse(version, out var dVersion)) {
                    return dVersion;
                }

                return null;
            }
        }

        /// <summary>
        ///     Returns the last part of the <see cref="PageUrl" /> slug
        /// </summary>
        public string Slug {
            get {
                var m = podcastUriSlugMatcher.Match(PageUrl);
                if(!m.Success) {
                    return null;
                }

                var slug = m.Groups[1].Value.Trim().ToLower();

                return slug;
            }
        }

        /// <summary>
        ///     Calculates the duration in seconds from the AudioFile.Duration property
        /// </summary>
        public long? DurationInSeconds {
            get {
                if(AudioFile?.Duration == null) {
                    return null;
                }

                var times = new int[3];
                var parts = AudioFile.Duration.Split(':');
                Array.Reverse(parts);

                for(var i = 0; i < parts.Length; ++i) {
                    if(int.TryParse(parts[i], out var part)) {
                        times[times.Length - 1 - i] = part;
                    }
                }

                var hours = times[0];
                var mins = times[1];
                var seconds = times[2];

                var totalSeconds = seconds + (mins * 60) + ((hours * 60) * 60);
                return totalSeconds > 0 ? totalSeconds : (long?) null;
            }
        }
    }
}