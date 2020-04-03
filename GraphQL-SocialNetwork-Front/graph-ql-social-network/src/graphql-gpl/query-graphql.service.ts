import { Injectable } from '@angular/core';
import { Query } from 'apollo-angular';
import gql from 'graphql-tag';

import { BlogResponse, BlogVariables } from 'src/graspql-type/types';

@Injectable()
export class BlogGetQuery extends Query<BlogResponse, BlogVariables> {
  document = gql`
    query GetBlogData($id: Int) {
      author(id: $id) {
        id
        name
        bio
      }
      posts(id: $id) {
        author {
          bio
        }
        categories
        comments {
          description
          count
          url
        }
      }
      socials(id: $id) {
        nickName
        type
      }
    }
	`;
}