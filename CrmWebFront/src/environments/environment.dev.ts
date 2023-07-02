// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  context: {
    app: {
      id: 'topInvestV6',
      version: '1.0.0',
      env: 'dev',
    },
    authenticationSTS: {
      activer: true,
      clientId: 'topInvest_web',
      clientSecret: 'cDJxGy4P3+9Ly5cu+3SN1pCItCocrllaPdv17PK9i3U=',
    },
    moteurCalcul: {
      login: 'moteurcalculweb',
      passe: 'Cl37}Qs3dX`*ey4(~v',
      motCleMoteurCalculWeb: '{moteurCalculWeb}',
    },
    map: {
      apiKey: 'AIzaSyC2LSEacvg_xmeYmidNPawUKbkTd7SjELo',
    },
    defaultWebApiUrlKey: 'api',
    urls: {
      api: 'https://localhost:44357',
    },
  },
  production: false,
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
