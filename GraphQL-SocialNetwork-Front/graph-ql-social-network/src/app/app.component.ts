import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { ApolloQueryResult } from 'apollo-client';
import { Observable } from 'rxjs';

import { BlogGetQuery } from '../graphql-gpl/query-graphql.service'
import { BlogResponse } from '../graspql-type/types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [BlogGetQuery]
})

export class AppComponent implements OnInit {
  title = 'graph-ql-social-network';

  public currentBlog$ : Observable<ApolloQueryResult<BlogResponse>>

  constructor(private readonly blogGetQuery: BlogGetQuery, private apollo:Apollo) {
  }

  ngOnInit() {
    this.currentBlog$ = this.apollo.watchQuery({
      query: this.blogGetQuery.document,
      variables: {
        id: 1
      }
    }).valueChanges as Observable<ApolloQueryResult<BlogResponse>> ;
  }
}
