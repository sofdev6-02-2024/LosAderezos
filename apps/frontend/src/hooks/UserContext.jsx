import { createContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { getDecodedToken } from "../services/AuthService";

export const UserContext = createContext();

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

UserProvider.propTypes = {
  children: PropTypes.node,
};
