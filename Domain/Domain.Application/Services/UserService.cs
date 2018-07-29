using Domain.Application._App;
using Domain.Model.Models;
using Domain.Model.Schemas;
using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Services {
    public class UserService: IUserService {
        #region Constructor
        private readonly IStoreProcedure<IBaseModel, UserRegisterSchema> _userRegister;
        private readonly IStoreProcedure<IBaseModel, ChangePasswordSchema> _changePassword;
        private readonly IStoreProcedure<IBaseModel, UserEditSchema> _editProfile;
        private readonly IStoreProcedure<IBaseModel, UserLoginSchema> _login;
        private readonly IStoreProcedure<IBaseModel, UserNextStepLoginSchema> _loginNextStep;
        private readonly IStoreProcedure<IBaseModel, UserSyncSchema> _userSync;
        private readonly IStoreProcedure<UserModel, UserGetSchema> _userGet;
        public UserService(IStoreProcedure<IBaseModel, UserRegisterSchema> userRegister,
            IStoreProcedure<IBaseModel, ChangePasswordSchema> changePassword,
            IStoreProcedure<IBaseModel, UserEditSchema> editProfile,
            IStoreProcedure<IBaseModel, UserLoginSchema> login,
            IStoreProcedure<IBaseModel, UserNextStepLoginSchema> loginNextStep,
            IStoreProcedure<IBaseModel, UserSyncSchema> userSync,
            IStoreProcedure<UserModel, UserGetSchema> userGet) {
            _userRegister = userRegister;
            _changePassword = changePassword;
            _editProfile = editProfile;
            _login = login;
            _loginNextStep = loginNextStep;
            _userSync = userSync;
            _userGet = userGet;
        }
        #endregion

        public async Task RegisterAsync(UserRegisterSchema model) {
            await _userRegister.ExecuteReturnLessAsync(model);
        }
        public async Task ChangePasswordAsync(ChangePasswordSchema model) {
            await _changePassword.ExecuteReturnLessAsync(model);
        }
        public async Task EditAsync(UserEditSchema model) {
            await _editProfile.ExecuteReturnLessAsync(model);
        }
        public async Task LoginAsync(UserLoginSchema model) {
            await _login.ExecuteReturnLessAsync(model);
        }
        public async Task LoginAsync(UserNextStepLoginSchema model) {
            await _loginNextStep.ExecuteReturnLessAsync(model);
        }
        public async Task SyncAsync(UserSyncSchema model) {
            await _userSync.ExecuteReturnLessAsync(model);
        }
        public async Task<UserModel> GetAsync(UserGetSchema model) {
            return await _userGet.ExecuteFirstOrDefaultAsync(model);
        }
    }
}
