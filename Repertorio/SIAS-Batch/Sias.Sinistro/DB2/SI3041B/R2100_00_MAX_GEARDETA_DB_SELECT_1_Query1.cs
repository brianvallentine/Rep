using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1 : QueryBasis<R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_GERACAO) + 1 , 1)
            INTO :GEARDETA-SEQ-GERACAO
            FROM SEGUROS.GE_AR_DETALHE
            WHERE NOM_ARQUIVO = 'SEGAB002'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_GERACAO) + 1 
							, 1)
											FROM SEGUROS.GE_AR_DETALHE
											WHERE NOM_ARQUIVO = 'SEGAB002'
											WITH UR";

            return query;
        }
        public string GEARDETA_SEQ_GERACAO { get; set; }

        public static R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1 Execute(R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1 r2100_00_MAX_GEARDETA_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_MAX_GEARDETA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_MAX_GEARDETA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEARDETA_SEQ_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}