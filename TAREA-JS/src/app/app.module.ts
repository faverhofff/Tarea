import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { IndexComponent } from './index/index.component';
import { TopMenuComponent } from './topmenu/top.menu.component';
import { SearchComponent } from './search/search.component';

import { AppRoutingModule } from './routing.module';
import { GlobalVars } from './app.global';

@NgModule({
  declarations: [
      IndexComponent,
      TopMenuComponent,
      SearchComponent
  ],
  imports: [
      BrowserModule,
      AppRoutingModule,
      HttpModule,
      FormsModule
  ],
  providers: [
    GlobalVars
  ],
  bootstrap: [TopMenuComponent]
})

export class AppModule { }
