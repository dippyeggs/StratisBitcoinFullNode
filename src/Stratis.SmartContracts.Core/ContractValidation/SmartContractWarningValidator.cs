﻿using System.Collections.Generic;
using System.Linq;
using Stratis.ModuleValidation.Net;
using Stratis.SmartContracts.Core.Compilation;

namespace Stratis.SmartContracts.Core.ContractValidation
{
    /// <summary>
    /// Validates any warn-level issues with a Smart Contract
    /// </summary>
    public class SmartContractWarningValidator : ISmartContractValidator
    {
        private static readonly IEnumerable<ITypeDefinitionValidator> TypeDefinitionValidators = new List<ITypeDefinitionValidator>
        {
            new FieldDefinitionValidator()
        };

        public SmartContractValidationResult Validate(SmartContractDecompilation decompilation)
        {
            var warnings = new List<ValidationResult>();
            var contractType = decompilation.ModuleDefinition.Types.FirstOrDefault(x => x.FullName != "<Module>");

            foreach (ITypeDefinitionValidator typeDefinitionValidator in TypeDefinitionValidators)
            {
                warnings.AddRange(typeDefinitionValidator.Validate(contractType));
            }

            return new SmartContractValidationResult(warnings);
        }
    }
}
