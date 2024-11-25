import { createContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { getDecodedToken } from "../services/AuthService";

export const UserContext = createContext();

export function UserProvider({ children }) {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const decodedUser = getDecodedToken();
    if (decodedUser) {
      const subIds = decodedUser.subsidiaryId.split(',');
      setUser({
        userId: decodedUser.userId,
        UserEmail: decodedUser.UserEmail,
        UserRol: decodedUser.UserRol,
        UserBirthDate: decodedUser.UserBirthDate,
        UserPhoneNumber: decodedUser.UserPhoneNumber,
        UserName: decodedUser.UserName,
        Token: decodedUser.Token,
        subsidiaryId: subIds[0],
        companyId: decodedUser.companyId
      });
    }
  }, []);

  const editUser = (updatedData) => {
    setUser(updatedData);
  };

  return (
    <UserContext.Provider value={{ user, editUser }}>
      {children}
    </UserContext.Provider>
  );
}

UserProvider.propTypes = {
  children: PropTypes.node,
};
