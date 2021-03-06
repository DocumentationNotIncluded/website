import { Component, OnInit } from '@angular/core';

import { SEOService } from '../../../services/seo/seo.service';

@Component({
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.scss']
})
export class FaqComponent implements OnInit {

  constructor(
    private seoService: SEOService
  ) { }

  ngOnInit() {
    this.seoService.setTitle('Frequently Asked Questions');
    this.seoService.setDescription('Frequently Asked Questions about the site and the podcast');
  }
}
