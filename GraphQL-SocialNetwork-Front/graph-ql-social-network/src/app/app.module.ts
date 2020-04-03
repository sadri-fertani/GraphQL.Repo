import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ApolloModule, APOLLO_OPTIONS } from 'apollo-angular';

import { AppComponent } from './app.component';
import ApolloClient from 'apollo-client';
import { InMemoryCache } from 'apollo-cache-inmemory';
import { HttpLinkModule, HttpLink } from "apollo-angular-link-http";
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpLinkModule,
    ApolloModule,
    AppRoutingModule
  ],
  providers: [{
    provide: APOLLO_OPTIONS,
    useFactory: (httpLink) => {
      return new ApolloClient({
        cache: new InMemoryCache(),
        link:  httpLink.create({
          uri: 'https://localhost:44378/graphql'
        })
      })
    },
    deps: [HttpLink]
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
