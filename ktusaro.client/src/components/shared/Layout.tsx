import React from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu.tsx';
import {Helmet} from "react-helmet";
import { Footer } from './Footer.tsx';

interface IProps {
  children: React.ReactNode;
}

export const Layout: React.FC<IProps> = ({children}) => {
    return (
      <div className=' dark:bg-gray-700 dark:border-gray-700'>
        <Helmet>
            <script src="https://use.fontawesome.com/releases/v5.15.4/js/all.js"></script>
        </Helmet>
        <NavMenu />
        <Container tag="main" fluid>
          {children}
        </Container>
        <Footer/>
      </div>
    );
}

