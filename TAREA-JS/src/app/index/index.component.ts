import { Http } from '@angular/http';
import { Component } from '@angular/core';
import { GlobalVars } from '../app.global';

@Component({
  selector: 'index-root',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
  providers: [ GlobalVars ]
})
export class IndexComponent {

    private urlIndex = this.globals.url+"index";
    private urlClear = this.globals.url+"clear";
    private result: any[];  
    url_index: any[];
    
    constructor(private http: Http, private globals: GlobalVars) {    
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
