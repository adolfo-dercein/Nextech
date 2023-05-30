import { eTypeItem } from "../model/enum/eType-Item";
import { TestBed } from "@angular/core/testing";
import { ItemService } from "./item-service";
import { environment } from "src/environments/environment";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CustomResponse } from "../model/custom-response";
  
describe('ItemService', () => 
{
    let service: ItemService;
    let httpController: HttpTestingController;

    let url = environment.api;
    
    const customResponse : CustomResponse =
    {
        statusCode: '200',
        message: '',
        success: true,
        data: 
        {
            pageNumber: 1,
            pageSize: 10, 
            total: 2,
            items: [
            {
                id: 123456,  
                deleted: false,     
                type: eTypeItem.Story,  
                by: 'Author',  
                date: 123123123, 
                text: 'Lorem Ipsum', 
                dead : false,    
                parent: 'Parent News', 
                poll: 'string',  
                kids: [123,123,123],
                url: 'string',  
                score: 123,
                title: 'Title',  
                parts: [123,123], 
                descendants: 'string'
            }, 
            {
                id: 123456,  
                deleted: false,     
                type: eTypeItem.Story,  
                by: 'Author',  
                date: 123123123, 
                text: 'Lorem Ipsum', 
                dead : false,    
                parent: 'Parent News', 
                poll: 'string',  
                kids: [123,123,123],
                url: 'string',  
                score: 123,
                title: 'Title',  
                parts: [123,123], 
                descendants: 'string'
            }]
        }
    };

    beforeEach(() => {
        TestBed.configureTestingModule({
        imports: [HttpClientTestingModule],
        });
        service = TestBed.inject(ItemService);
        httpController = TestBed.inject(HttpTestingController);
    });
  
    it('should call getItemList and return an ItemResponse', () => 
    {      
        service.getItemList(1, 10).subscribe((res) => 
        {
            expect(res).toEqual(customResponse.data);
        });
      
        const req = httpController.expectOne({
            method: 'GET',
            url: `${url}/item/GetStories?pageNumber=1&pageSize=10`,
        });
  
        req.flush(customResponse);
    });

    it('should call getSearchItemList and return an ItemResponse', () => 
    {      
        service.getSearchItemList("lorem").subscribe((res) => 
        {
            expect(res).toEqual(customResponse.data);
        });
      
        const req = httpController.expectOne({
            method: 'GET',
            url: `${url}/item/SearchStories?searchTerm=lorem`,
        });
  
        req.flush(customResponse);
    });
});