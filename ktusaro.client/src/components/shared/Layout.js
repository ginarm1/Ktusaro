import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import {Helmet} from "react-helmet";
import { Footer } from './Footer';

export class Layout extends Component {
  static displayName = Layout.name;

  
  render() {
    return (
      <div>
        <Helmet>
            <script src="https://use.fontawesome.com/releases/v5.15.4/js/all.js"></script>
        </Helmet>
        <NavMenu />
        <Container tag="main">
          {this.props.children}
        </Container>
        <Footer/>
      </div>
    );
  }
}

