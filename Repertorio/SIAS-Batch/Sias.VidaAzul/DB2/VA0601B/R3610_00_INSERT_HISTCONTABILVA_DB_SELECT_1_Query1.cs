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
    public class R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 : QueryBasis<R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA
            INTO :WHOST-NRPARCEL-56
            FROM SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF
            AND NUM_PARCELA = :DCLPARCELAS-VIDAZUL.NUM-PARCELA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA
											FROM SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_CERTIFICADO = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND NUM_PARCELA = '{this.NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string WHOST_NRPARCEL_56 { get; set; }
        public string NUM_PARCELA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 Execute(R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 r3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1)
        {
            var ths = r3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NRPARCEL_56 = result[i++].Value?.ToString();
            return dta;
        }

    }
}