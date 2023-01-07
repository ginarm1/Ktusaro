import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import {Helmet} from "react-helmet";
import { Footer } from './Footer';

export const Layout = ({children}) => {
    return (
      <div>
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

