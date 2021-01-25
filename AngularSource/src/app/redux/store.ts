import { MedicalData } from '../models/MedicalData';

export class Store{
    public data:MedicalData;
    public allData:MedicalData[]=[];
    public calculate:number;


    public getAllDataError:string;
    public addDataError:string;
    public calculateError:string;
}