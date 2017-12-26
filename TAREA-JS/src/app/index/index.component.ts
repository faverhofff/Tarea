import { Http } from '@angular/http';
import { Component } from '@angular/core';

@Component({
  selector: 'index-root',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent {

    private urlIndex = "http://localhost:49772/api/index";
    private urlClear = "http://localhost:49772/api/clear";
    private result: any[];  
    url_index: any[];
    
    constructor(private http: Http) {    
    }

    indexer() {
      this.http.get(this.urlIndex, {
        params: {
          Url: this.url_index
        },
        })
        .subscribe(response => {
          this.result = response.json();
        },
        (error: Response) => {
          if ( error.status != 0 )
            alert(error.statusText);
        });
    }

    clearDB() {
      this.http.get(this.urlClear).subscribe(response => {
      });        
    }

    haveItems() {
      return this.result.length > 0;
    }
}
