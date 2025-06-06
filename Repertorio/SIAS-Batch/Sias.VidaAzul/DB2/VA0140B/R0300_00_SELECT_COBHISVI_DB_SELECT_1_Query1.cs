using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1 : QueryBasis<R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCO_AVISO
            ,AGE_AVISO
            ,NUM_AVISO_CREDITO
            INTO :COBHISVI-BCO-AVISO
            ,:COBHISVI-AGE-AVISO
            ,:COBHISVI-NUM-AVISO-CREDITO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND NUM_PARCELA = :HISCONPA-NUM-PARCELA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BCO_AVISO
											,AGE_AVISO
											,NUM_AVISO_CREDITO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string COBHISVI_BCO_AVISO { get; set; }
        public string COBHISVI_AGE_AVISO { get; set; }
        public string COBHISVI_NUM_AVISO_CREDITO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1 Execute(R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1 r0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_BCO_AVISO = result[i++].Value?.ToString();
            dta.COBHISVI_AGE_AVISO = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}