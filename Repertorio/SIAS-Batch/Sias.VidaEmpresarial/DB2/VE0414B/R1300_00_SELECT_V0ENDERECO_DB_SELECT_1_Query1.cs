using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP
            INTO :DCLENDERECOS.ENDERECO-ENDERECO,
            :DCLENDERECOS.ENDERECO-BAIRRO,
            :DCLENDERECOS.ENDERECO-CIDADE,
            :DCLENDERECOS.ENDERECO-SIGLA-UF,
            :DCLENDERECOS.ENDERECO-CEP
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE =
            :DCLTERMO-ADESAO.TERMOADE-COD-CLIENTE
            AND OCORR_ENDERECO = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDERECO
							,
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE =
											'{this.TERMOADE_COD_CLIENTE}'
											AND OCORR_ENDERECO = 1";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string ENDERECO_CEP { get; set; }
        public string TERMOADE_COD_CLIENTE { get; set; }

        public static R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.ENDERECO_SIGLA_UF = result[i++].Value?.ToString();
            dta.ENDERECO_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}