using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1 : QueryBasis<R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            , COD_IDENTIFICACAO
            , NOM_ORGAO_EXP
            , DTH_EXPEDICAO
            , COD_UF
            INTO :GEDOCCLI-COD-CLIENTE
            , :GEDOCCLI-COD-IDENTIFICACAO
            , :GEDOCCLI-NOM-ORGAO-EXP
            , :GEDOCCLI-DTH-EXPEDICAO
            , :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA
            FROM SEGUROS.GE_DOC_CLIENTE
            WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											, COD_IDENTIFICACAO
											, NOM_ORGAO_EXP
											, DTH_EXPEDICAO
											, COD_UF
											FROM SEGUROS.GE_DOC_CLIENTE
											WHERE COD_CLIENTE = '{this.COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string GEDOCCLI_COD_CLIENTE { get; set; }
        public string GEDOCCLI_COD_IDENTIFICACAO { get; set; }
        public string GEDOCCLI_NOM_ORGAO_EXP { get; set; }
        public string GEDOCCLI_DTH_EXPEDICAO { get; set; }
        public string GEDOCCLI_COD_UF { get; set; }
        public string VIND_UF_EXPEDIDORA { get; set; }
        public string COD_CLIENTE { get; set; }

        public static R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1 Execute(R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1 r2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1)
        {
            var ths = r2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2314_00_TRATA_GE_DOC_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEDOCCLI_COD_CLIENTE = result[i++].Value?.ToString();
            dta.GEDOCCLI_COD_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.GEDOCCLI_NOM_ORGAO_EXP = result[i++].Value?.ToString();
            dta.GEDOCCLI_DTH_EXPEDICAO = result[i++].Value?.ToString();
            dta.GEDOCCLI_COD_UF = result[i++].Value?.ToString();
            dta.VIND_UF_EXPEDIDORA = string.IsNullOrWhiteSpace(dta.GEDOCCLI_COD_UF) ? "-1" : "0";
            return dta;
        }

    }
}