using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				, TIMESTAMP = CURRENT TIMESTAMP
				WHERE  IDE_SISTEMA = 'VA'
				AND COD_RELATORIO = 'VA0412B'
				AND NUM_APOLICE =  '{this.MOVIMVGA_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.MOVIMVGA_COD_SUBGRUPO}'
				AND NUM_CERTIFICADO =  '{this.MOVIMVGA_NUM_CERTIFICADO}'
				AND NUM_COPIAS = 2
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO { get; set; }
        public string MOVIMVGA_NUM_APOLICE { get; set; }

        public static void Execute(R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 r0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0890_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}