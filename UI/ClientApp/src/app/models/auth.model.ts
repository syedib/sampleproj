export interface CreateUser
{
  FullName: string;
  UsreName: string;
  Password: string;
  DateOfBirth: Date;
}

export interface LoginUser
{
  userName: string;
  password: string;
}
