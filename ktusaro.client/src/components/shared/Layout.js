import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import {Helmet} from "react-helmet";
import { Footer } from './Footer';

export const Layout = ({children}) => {
    return (
      <div className=' dark:bg-gray-700 dark:border-gray-700'>
        <Helmet>
            <script src="https://use.fontawesome.com/releases/v5.15.4/js/all.js"></script>
        </Helmet>
        <NavMenu />
        <Container tag="main">
          {children}
        </Container>
        <Footer/>
      </div>
    );
}

