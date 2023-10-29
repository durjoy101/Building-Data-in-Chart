import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReadingDTO } from '../models/ReadingDTO';
import { Building } from '../models/Building';
import { DataField } from '../models/DataField';
import { Object } from '../models/Object';

@Injectable()
export class BuildingDataService {

constructor(private http: HttpClient) { }

btnsearch(
    buildingId: string | undefined,
    objectId: string | undefined,
    dataFieldId: string | undefined,
    startDate: Date | undefined,
    endDate: Date | undefined
  ): Observable<ReadingDTO[]> {
    const params = new HttpParams()
    .set('buildingID', buildingId?.toString() || '')
    .set('objectID', objectId?.toString() || '')
    .set('dataFieldID', dataFieldId?.toString() || '')
    .set('startTime', startDate ? startDate.toISOString() : '')
    .set('endTime', endDate ? endDate.toISOString() : '');
    return this.http.get<ReadingDTO[]>("https://localhost:7112/api/Readings", {params});
  }

  getBuildings(): Observable<Building[]>{
    return this.http.get<Building[]>("https://localhost:7112/api/Buildings");
  }

  getObjects(): Observable<Object[]>{
    return this.http.get<Object[]>("https://localhost:7112/api/Objects");
  }

  getDataFields(): Observable<DataField[]>{
    return this.http.get<DataField[]>("https://localhost:7112/api/DataFields");
  }




}
