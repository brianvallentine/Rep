using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 : QueryBasis<R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT D.COD_FONTE
            INTO :FONTES-COD-FONTE
            FROM SEGUROS.AGENCIAS A ,
            SEGUROS.AGENCIAS_CEF B ,
            SEGUROS.MALHA_CEF C ,
            SEGUROS.FONTES D
            WHERE A.COD_BANCO = :AGENCIAS-COD-BANCO
            AND A.CIDADE = :AGENCIAS-CIDADE
            AND A.SIGLA_UF = :AGENCIAS-SIGLA-UF
            AND A.COD_AGENCIA = B.COD_AGENCIA
            AND B.COD_SUREG BETWEEN 2500 AND 5000
            AND B.COD_SUREG = C.COD_SUREG
            AND D.COD_FONTE = C.COD_FONTE
            AND D.SIGLA_UF = A.SIGLA_UF
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT D.COD_FONTE
											FROM SEGUROS.AGENCIAS A 
							,
											SEGUROS.AGENCIAS_CEF B 
							,
											SEGUROS.MALHA_CEF C 
							,
											SEGUROS.FONTES D
											WHERE A.COD_BANCO = '{this.AGENCIAS_COD_BANCO}'
											AND A.CIDADE = '{this.AGENCIAS_CIDADE}'
											AND A.SIGLA_UF = '{this.AGENCIAS_SIGLA_UF}'
											AND A.COD_AGENCIA = B.COD_AGENCIA
											AND B.COD_SUREG BETWEEN 2500 AND 5000
											AND B.COD_SUREG = C.COD_SUREG
											AND D.COD_FONTE = C.COD_FONTE
											AND D.SIGLA_UF = A.SIGLA_UF
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string FONTES_COD_FONTE { get; set; }
        public string AGENCIAS_COD_BANCO { get; set; }
        public string AGENCIAS_SIGLA_UF { get; set; }
        public string AGENCIAS_CIDADE { get; set; }

        public static R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 Execute(R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 r0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1)
        {
            var ths = r0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}