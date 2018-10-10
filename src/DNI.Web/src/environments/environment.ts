const pkgJson = require('../../package.json');
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
    production: false,
    webUri: 'http://spikeh.ddns.net:4200/',
    apiBaseUri: 'http://spikeh.ddns.net:12341/',
    recaptchaSiteKey: '6Lcv_3MUAAAAAPTlA1F3Jk2X3mc_Vnixqbgk3pgv',
    version: pkgJson.version,
    versionText: 'The MVP'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
import 'zone.js/dist/zone-error';  // Included with Angular CLI.