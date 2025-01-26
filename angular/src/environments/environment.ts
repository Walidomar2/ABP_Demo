import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Demo',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44375/',
    redirectUri: baseUrl,
    clientId: 'Demo_App',
    responseType: 'code',
    scope: 'offline_access Demo',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44375',
      rootNamespace: 'ABP.Demo',
    },
  },
} as Environment;
