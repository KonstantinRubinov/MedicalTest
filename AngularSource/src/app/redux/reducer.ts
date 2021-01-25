import { Store } from "./store";
import { Action } from "./action";
import { ActionType } from "./action-type";
import { MedicalData } from "../models/MedicalData";

export class Reducer{
    public static reduce(oldStore: Store, action:Action):Store{
        let newStore:Store = {...oldStore};

        switch(action.type){
                
            case ActionType.GetAllData:
                newStore.allData=action.payload.map(x => new MedicalData(x.dataKey, x.platelets, x.albumin, x.enterDate));
                break;

            case ActionType.GetAllDataError:
                newStore.getAllDataError=action.payload;
                break;

            case ActionType.AddData:
                newStore.data=action.payload;
                newStore.allData.push(new MedicalData(action.payload.dataKey, action.payload.platelets, action.payload.albumin, action.payload.enterDate));
                break;

            case ActionType.AddDataError:
                newStore.addDataError=action.payload;
                break;

            case ActionType.Calculate:
                newStore.calculate=action.payload;
                break;

            case ActionType.CalculateError:
                newStore.calculateError=action.payload;
                break;
                
            default:
                break;
        }
        return newStore;
    }
}