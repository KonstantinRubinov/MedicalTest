import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { DataToCalculate } from 'src/app/models/DataToCalculate';
import { MedicalData } from 'src/app/models/MedicalData';
import { Action } from 'src/app/redux/action';
import { ActionType } from 'src/app/redux/action-type';
import { Store } from 'src/app/redux/store';
import { calculate, fullLink } from 'src/environments/environment';
import { LogService } from '../log.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  public constructor(private http: HttpClient,
    private redux: NgRedux<Store>,
    private logger: LogService) { }

  public GetAllData(): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.get<MedicalData>(fullLink, { headers: he });
    observable.subscribe(data=>{
    const action: Action={type:ActionType.GetAllData, payload:data};
    this.redux.dispatch(action);
    this.logger.debug("GetAllData: ", data);
    }, error => {
    const action: Action={type:ActionType.GetAllDataError, payload:error.message};
    this.redux.dispatch(action);
    this.logger.error("GetAllDataError: ", error.message);
    });
  }

  public AddData(medicalData:MedicalData): void {
    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.post<MedicalData>(fullLink, medicalData, { headers: he });
    observable.subscribe(data=>{
    const action: Action={type:ActionType.AddData, payload:data};
    this.redux.dispatch(action);
    this.logger.debug("AddData: ", data);
    }, error => {
    const action: Action={type:ActionType.AddDataError, payload:error.message};
    this.redux.dispatch(action);
    this.logger.error("AddDataError: ", error.message);
    });
  }

  public Calculate(platelet:number, albumin:number, userAction:string){
    let dataToCalculate = new DataToCalculate(platelet, albumin, userAction)


    let he = new HttpHeaders({'Content-Type':  'application/json'});
    let observable = this.http.post<number>(calculate, dataToCalculate, { headers: he });
    observable.subscribe(data=>{
    const action: Action={type:ActionType.Calculate, payload:data};
    this.redux.dispatch(action);
    this.logger.debug("Calculate: ", data);
    }, error => {
    const action: Action={type:ActionType.CalculateError, payload:error.message};
    this.redux.dispatch(action);
    this.logger.error("CalculateError: ", error.message);
    });
  }
}