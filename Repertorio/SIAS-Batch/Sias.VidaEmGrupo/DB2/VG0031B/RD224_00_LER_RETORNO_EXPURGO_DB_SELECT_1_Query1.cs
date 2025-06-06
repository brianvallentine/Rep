using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1 : QueryBasis<RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            SITUACAO_RETORNO
            INTO :DCLRETORNO-EXPURGO.RETOREXP-NUM-APOLICE,
            :DCLRETORNO-EXPURGO.RETOREXP-SITUACAO-RETORNO
            FROM EXPURGO.RETORNO_EXPURGO
            WHERE NUM_APOLICE = :V0SEG-NUM-APOL
            AND NUM_ITEM = :V0SEG-NUM-ITEM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											SITUACAO_RETORNO
											FROM EXPURGO.RETORNO_EXPURGO
											WHERE NUM_APOLICE = '{this.V0SEG_NUM_APOL}'
											AND NUM_ITEM = '{this.V0SEG_NUM_ITEM}'";

            return query;
        }
        public string RETOREXP_NUM_APOLICE { get; set; }
        public string RETOREXP_SITUACAO_RETORNO { get; set; }
        public string V0SEG_NUM_APOL { get; set; }
        public string V0SEG_NUM_ITEM { get; set; }

        public static RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1 Execute(RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1 rD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1)
        {
            var ths = rD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RETOREXP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RETOREXP_SITUACAO_RETORNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}