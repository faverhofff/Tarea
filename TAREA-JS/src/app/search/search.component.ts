import { Http } from '@angular/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {

   private url = "http://localhost:49772/api/search";
   private data: any[];
   private isQuery: boolean;
   search_word: any[];

   constructor(private http: Http) {    
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
