export const Footer  = () => {
    return (
      <footer className="p-4 bg-white rounded-lg shadow md:px-6 md:py-8 dark:bg-gray-900">
        <div className="flex pl-4 items-center justify-between">
          <a
            href="https://sa.ktu.edu/"
            className="flex items-center mb-4 sm:mb-0"
          >
            <img
              src="ktusa_logo.png"
              className="h-14 mr-3"
              alt="KTU SA Logo"
            />
            <span className="pl-2 self-center text-2xl font-semibold whitespace-nowrap dark:text-white">
              KTU SA
            </span>
          </a>
          <ul className="flex flex-wrap items-center mb-6 text-sm text-gray-500 sm:mb-0 dark:text-gray-400">
            <li className="mr-4 hover:underline md:mr-6">
              <a href="https://www.facebook.com/KTU.SA">
                <span className="fa-stack fa-lg">
                  <i className="fas fa-circle fa-stack-2x"></i>
                  <i className="fab fa-facebook-f fa-stack-1x fa-inverse"></i>
                </span>
              </a>
            </li>
            <li className="mr-4 hover:underline md:mr-6">
              <a href="https://www.instagram.com/ktu_sa/">
                <span className="fa-stack fa-lg">
                  <i className="fas fa-circle fa-stack-2x"></i>
                  <i className="fab fa-instagram fa-stack-1x fa-inverse"></i>
                </span>
              </a>
            </li>
            <li className="mr-4 hover:underline md:mr-6">
              <a href="https://github.com/ginarm1">
                <span className="fa-stack fa-lg">
                  <i className="fas fa-circle fa-stack-2x"></i>
                  <i className="fab fa-github fa-stack-1x fa-inverse"></i>
                </span>
              </a>
            </li>
          </ul>
        </div>
        <hr className="my-6 border-gray-200 sm:mx-auto dark:border-gray-700 lg:my-8" />
        <span className="block text-sm text-gray-500 text-center">
          © 2023 - KTU SA Renginių organizavimo IS
        </span>
      </footer>
    );
}

// export class Footer extends Component {
//   render() {
//     return (
//       <footer className="p-4 bg-white rounded-lg shadow md:px-6 md:py-8 dark:bg-gray-900">
//         <div className="flex pl-4 items-center justify-between">
//           <a
//             href="https://sa.ktu.edu/"
//             className="flex items-center mb-4 sm:mb-0"
//           >
//             <img
//               src="ktusa_logo.png"
//               className="h-14 mr-3"
//               alt="KTU SA Logo"
//             />
//             <span className="pl-2 self-center text-2xl font-semibold whitespace-nowrap dark:text-white">
//               KTU SA
//             </span>
//           </a>
//           <ul className="flex flex-wrap items-center mb-6 text-sm text-gray-500 sm:mb-0 dark:text-gray-400">
//             <li className="mr-4 hover:underline md:mr-6">
//               <a href="https://www.facebook.com/KTU.SA">
//                 <span className="fa-stack fa-lg">
//                   <i className="fas fa-circle fa-stack-2x"></i>
//                   <i className="fab fa-facebook-f fa-stack-1x fa-inverse"></i>
//                 </span>
//               </a>
//             </li>
//             <li className="mr-4 hover:underline md:mr-6">
//               <a href="https://www.instagram.com/ktu_sa/">
//                 <span className="fa-stack fa-lg">
//                   <i className="fas fa-circle fa-stack-2x"></i>
//                   <i className="fab fa-instagram fa-stack-1x fa-inverse"></i>
//                 </span>
//               </a>
//             </li>
//             <li className="mr-4 hover:underline md:mr-6">
//               <a href="https://github.com/ginarm1">
//                 <span className="fa-stack fa-lg">
//                   <i className="fas fa-circle fa-stack-2x"></i>
//                   <i className="fab fa-github fa-stack-1x fa-inverse"></i>
//                 </span>
//               </a>
//             </li>
//           </ul>
//         </div>
//         <hr className="my-6 border-gray-200 sm:mx-auto dark:border-gray-700 lg:my-8" />
//         <span className="block text-sm text-gray-500 text-center dark:text-gray-400">
//           © 2023 - KTU SA Renginių organizavimo IS
//         </span>
//       </footer>
//       //   <footer>
//       //       <div className="container px-4 px-lg-5">
//       //           <div className="row gx-4 gx-lg-5 justify-content-center">
//       //               <div className="col-md-10 col-lg-8 col-xl-7">
//       //                   <ul className="list-inline text-center">
//       //                       <li className="list-inline-item">
//       //                           <a href="https://www.facebook.com/KTU.SA">
//       //                               <span className="fa-stack fa-lg">
//       //                                   <i className="fas fa-circle fa-stack-2x"></i>
//       //                                   <i className="fab fa-facebook-f fa-stack-1x fa-inverse"></i>
//       //                               </span>
//       //                           </a>
//       //                       </li>
//       //                       <li className="list-inline-item">
//       //                           <a href="https://www.instagram.com/ktu_sa/">
//       //                               <span className="fa-stack fa-lg">
//       //                                   <i className="fas fa-circle fa-stack-2x"></i>
//       //                                   <i className="fab fa-instagram fa-stack-1x fa-inverse"></i>
//       //                               </span>
//       //                           </a>
//       //                       </li>
//       //                       <li className="list-inline-item">
//       //                           <a href="https://github.com/ginarm1">
//       //                               <span className="fa-stack fa-lg">
//       //                                   <i className="fas fa-circle fa-stack-2x"></i>
//       //                                   <i className="fab fa-github fa-stack-1x fa-inverse"></i>
//       //                               </span>
//       //                           </a>
//       //                       </li>
//       //                   </ul>
//       //                   <div className="small text-center">Copyright &copy; 2023 - KTU SA Renginių organizavimo IS </div>
//       //               </div>
//       //           </div>
//       //       </div>
//       //   </footer>
//     );
//   }
// }
