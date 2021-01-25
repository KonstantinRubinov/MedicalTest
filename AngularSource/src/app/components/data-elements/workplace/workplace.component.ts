import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { Unsubscribe } from 'redux';
import { MedicalData } from 'src/app/models/MedicalData';
import { Store } from 'src/app/redux/store';
import { DataService } from 'src/app/services/ApiConnections/data.service';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-workplace',
  templateUrl: './workplace.component.html',
  styleUrls: ['./workplace.component.css']
})
export class WorkplaceComponent implements OnInit, OnDestroy {
  private unsubscribe:Unsubscribe;
  public datetime:Date=new Date();
  public platelet:number=-1;
  public albumin:number=-1;
  
  public userAction:string;

  
  public data:MedicalData;
  public allMedicalData:MedicalData[]=[];
  public result:number=0;


  public actionChoises:string[] = ["+","-","*","/"]

  public headers:string[] = ["date","platelets","albumin"]

  constructor(private dataService: DataService,
    private logger: LogService,
    private redux:NgRedux<Store>){}

    public ngOnInit(): void {
      this.dataService.GetAllData();
      this.unsubscribe = this.redux.subscribe(()=>{
        this.data = this.redux.getState().data;
        this.allMedicalData = this.sortData(this.redux.getState().allData);
        this.result = this.redux.getState().calculate;
      });
      this.data = this.redux.getState().data;
      this.allMedicalData = this.sortData(this.redux.getState().allData);
      this.result = this.redux.getState().calculate;
    }

  public Calculate(){
    this.dataService.Calculate(this.platelet, this.albumin, this.userAction)
  }
  public AddData(){
    let medicalData = new MedicalData();
    medicalData.platelets=this.platelet;
    medicalData.albumin=this.albumin;
    medicalData.enterDate=new Date(Date.now());
    this.dataService.AddData(medicalData);
  }

  sortData(data) {
    return data.sort((a, b) => {
      return <any>new Date(a.enterDate) - <any>new Date(b.enterDate);
    });
  }

  public ngOnDestroy(): void {
    this.unsubscribe();
  }

}
