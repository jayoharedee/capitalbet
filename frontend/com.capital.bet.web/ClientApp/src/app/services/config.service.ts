import { Injectable } from '@angular/core';
import conf from '../config.json';

/** Configuration service */
@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  /** Authentication Server Url */
  public get AuthenticationServer(): string { return conf.AuthUrl; }
  /** Application  Server Base Url */
  public get AppplicationUrl(): string { return conf.BaseUrl; }
  /** Api Server Base Url */
  public get ApiUrl(): string { return conf.ApiUrl; }
  /** Version String */
  public get VersionString(): string { return `${conf.MajVer}.${conf.MinVer}.${conf.Revision}`; }
  /** Major Release Version */
  public get MajorVersion(): number { return conf.MajVer; }
  /** Minor Release Version */
  public get MinorVersion(): number { return conf.MinVer; }
  /** Revision Version Number */
  public get RevisionNumber(): number { return conf.Revision; }
  /** Application Friendly Name */
  public get ApplicationName(): string { return conf.AppName; }
  /** Facebook Url */
  public get FacebookUrl(): string { return conf.FacebookUrl; }
  /** Twitter Url */
  public get TwitterUrl(): string { return conf.TwitterUrl; }

  constructor() {
  }
}
