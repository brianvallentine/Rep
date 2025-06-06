using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1 : QueryBasis<R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO ,
            NUM_PARCELA
            INTO :WS-NUM-CERTIFICADO ,
            :WS-NUM-PARCELA
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_TITULO = :WHOST-NRTITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO 
							,
											NUM_PARCELA
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_TITULO = '{this.WHOST_NRTITULO}'";

            return query;
        }
        public string WS_NUM_CERTIFICADO { get; set; }
        public string WS_NUM_PARCELA { get; set; }
        public string WHOST_NRTITULO { get; set; }

        public static R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1 Execute(R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1 r1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1)
        {
            var ths = r1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1();
            var i = 0;
            dta.WS_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.WS_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}