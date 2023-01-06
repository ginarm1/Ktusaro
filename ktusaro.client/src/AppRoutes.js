import { NotFound } from "./components/exceptions/NotFound";
import { Events } from "./components/pages/Events";
import { Home } from "./components/pages/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/events',
    element: <Events />
  },
  {
    path: '*',
    element: <NotFound/>
  }
];

export default AppRoutes;