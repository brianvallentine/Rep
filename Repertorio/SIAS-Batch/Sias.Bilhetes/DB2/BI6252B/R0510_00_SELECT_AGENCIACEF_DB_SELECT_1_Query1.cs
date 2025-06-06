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
    public class R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT D.COD_FONTE
            INTO :FONTES-COD-FONTE
            FROM SEGUROS.AGENCIAS_CEF B ,
            SEGUROS.MALHA_CEF C ,
            SEGUROS.FONTES D
            WHERE B.COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            AND B.COD_SUREG BETWEEN 2500 AND 5000
            AND B.COD_SUREG = C.COD_SUREG
            AND C.COD_FONTE = D.COD_FONTE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT D.COD_FONTE
											FROM SEGUROS.AGENCIAS_CEF B 
							,
											SEGUROS.MALHA_CEF C 
							,
											SEGUROS.FONTES D
											WHERE B.COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'
											AND B.COD_SUREG BETWEEN 2500 AND 5000
											AND B.COD_SUREG = C.COD_SUREG
											AND C.COD_FONTE = D.COD_FONTE
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string FONTES_COD_FONTE { get; set; }
        public string AGENCCEF_COD_AGENCIA { get; set; }

        public static R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1 Execute(R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1 r0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}