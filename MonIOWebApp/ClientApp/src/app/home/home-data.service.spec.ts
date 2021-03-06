import { TestBed, inject } from '@angular/core/testing';

import { HomeDataService } from './home-data.service';
import { MockApiDataService} from '../mock-services/mock-api-data.service';


describe('HomeDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HomeDataService]
    });
  });

  it('should be created', inject([HomeDataService], (service: HomeDataService) => {
    expect(service).toBeTruthy();
  }));

  it('should get values from dataService', inject([HomeDataService, MockApiDataService], 
    (service: HomeDataService, apiService:MockApiDataService) => {
      apiService.loadHomeData(10, 11, 12);
      service.GetBudgets().subscribe( x=>
        expect(x).toBe(10)
      );
      service.GetExpenses().subscribe( x=>
        expect(x).toBe(11)
      );
      service.GetSavings().subscribe( x=>
        expect(x).toBe(12)
      );
    }));
});
