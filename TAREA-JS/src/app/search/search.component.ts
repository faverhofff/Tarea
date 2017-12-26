import { Http } from '@angular/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GlobalVars } from '../app.global';

@Component({
  selector: 'app-root',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [ GlobalVars ]
})
export class SearchComponent {

   private url = this.globals.url+"search";
   private data: any[];
   private isQuery: boolean;
   search_word: any[];

   constructor(private http: Http, private globals: GlobalVars) {    
   }
   
    search() {
      this.http.get(this.url, {
        params: {
          Word: this.search_word
        }
      }).subscribe(response => {
       this.data = response.json();
       this.isQuery = true;
      });
    }

}
