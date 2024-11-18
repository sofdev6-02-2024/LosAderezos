import { createContext, useContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { getDecodedToken } from "./AuthService";

const UserContext = createContext();

export function UserProvider({ children }) {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const decodedUser = getDecodedToken();
    if (decodedUser) {
      setUser(decodedUser);
    }
  }, []);

  return <UserContext.Provider value={user}>{children}</UserContext.Provider>;
}

export function useUser() {
  return useContext(UserContext);
}

UserProvider.propTypes = {
  children: PropTypes.node,
};
