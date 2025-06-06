using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1 : QueryBasis<R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_ENDERECO
            INTO :OCORR-ENDERECO
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            AND ENDERECO = :ENDERECO
            AND COMPL_ENDER = :COMPL-ENDER
            AND CIDADE = :CIDADE
            AND BAIRRO = :BAIRRO
            AND CEP = :CEP
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_ENDERECO
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											AND ENDERECO = '{this.ENDERECO}'
											AND COMPL_ENDER = '{this.COMPL_ENDER}'
											AND CIDADE = '{this.CIDADE}'
											AND BAIRRO = '{this.BAIRRO}'
											AND CEP = '{this.CEP}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string OCORR_ENDERECO { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }
        public string COMPL_ENDER { get; set; }
        public string ENDERECO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public string CEP { get; set; }

        public static R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1 Execute(R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1 r8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1)
        {
            var ths = r8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8023_00_VERIFICA_ENDEREC_PES_DB_SELECT_1_Query1();
            var i = 0;
            dta.OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}