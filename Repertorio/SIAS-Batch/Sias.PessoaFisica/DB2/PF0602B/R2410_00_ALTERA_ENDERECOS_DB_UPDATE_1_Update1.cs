using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1 : QueryBasis<R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDERECOS
				SET ENDERECO =  '{this.ENDERECO}',
				BAIRRO =  '{this.BAIRRO}',
				CIDADE =  '{this.CIDADE}',
				SIGLA_UF =  '{this.SIGLA_UF}',
				CEP =  '{this.CEP}',
				DDD =  '{this.WHOST_DDD}',
				TELEFONE =  '{this.WHOST_TELEFONE}',
				FAX =  '{this.WHOST_FAX}'
				WHERE  COD_CLIENTE =  '{this.COD_CLIENTE}'
				AND OCORR_ENDERECO = 1
				AND COD_ENDERECO = 2";

            return query;
        }
        public string ENDERECO { get; set; }
        public string SIGLA_UF { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string CEP { get; set; }
        public string WHOST_TELEFONE { get; set; }
        public string WHOST_DDD { get; set; }
        public string WHOST_FAX { get; set; }
        public string COD_CLIENTE { get; set; }

        public static void Execute(R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1 r2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1)
        {
            var ths = r2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}