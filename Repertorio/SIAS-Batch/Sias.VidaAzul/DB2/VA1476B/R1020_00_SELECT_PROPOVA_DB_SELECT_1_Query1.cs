using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO,
            OCOREND
            , COD_PRODUTO
            INTO :PROPOVA-NUM-CERTIFICADO ,
            :PROPOVA-OCOREND
            , :WS-COD-PRODUTO
            FROM
            SEGUROS.PROPOSTAS_VA
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            AND NUM_APOLICE IN
            (
            0109300000550.,0109300000598.,0109300000559.,
            0109300000709.,0109300000909.,0109300001294.,
            0109300001311.,0109300001391.,0109300001392.,
            0109300001393.,0109300001394.,0109300001553.,
            0109300001575.,0109300001679.,0109300001680.,
            0109300002001.,0109300002002.,0109300002003.,
            0109300002004.,0109300002005.,0109300002006.,
            0109300002007.,0109300002008.,0109300002010.,
            0109300001966.,0109300001970.,0109300001971.,
            0109300001976.,0109300001977.,0109300001978.
            ,3009300001559.
            ,3009300001909.
            ,3009300011970.
            ,3009300011971.
            ,3009300011977.
            ,3009300011978.
            ,3009300012002.
            ,3009300012003.
            ,3009300012005.
            ,3009300012006.
            ,3009300012008.
            ,3009300012010.
            ,3009300012344.
            ,3009300012358.
            ,3009300007513.
            ,3009300007514.
            )
            AND DATA_QUITACAO < :SISTEMAS-DATA-MOV-ABERTO-30
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
							,
											OCOREND
											, COD_PRODUTO
											FROM
											SEGUROS.PROPOSTAS_VA
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'
											AND NUM_APOLICE IN
											(
											0109300000550.
							,0109300000598.
							,0109300000559.
							,
											0109300000709.
							,0109300000909.
							,0109300001294.
							,
											0109300001311.
							,0109300001391.
							,0109300001392.
							,
											0109300001393.
							,0109300001394.
							,0109300001553.
							,
											0109300001575.
							,0109300001679.
							,0109300001680.
							,
											0109300002001.
							,0109300002002.
							,0109300002003.
							,
											0109300002004.
							,0109300002005.
							,0109300002006.
							,
											0109300002007.
							,0109300002008.
							,0109300002010.
							,
											0109300001966.
							,0109300001970.
							,0109300001971.
							,
											0109300001976.
							,0109300001977.
							,0109300001978.
											,3009300001559.
											,3009300001909.
											,3009300011970.
											,3009300011971.
											,3009300011977.
											,3009300011978.
											,3009300012002.
											,3009300012003.
											,3009300012005.
											,3009300012006.
											,3009300012008.
											,3009300012010.
											,3009300012344.
											,3009300012358.
											,3009300007513.
											,3009300007514.
											)
											AND DATA_QUITACAO < '{this.SISTEMAS_DATA_MOV_ABERTO_30}'
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string WS_COD_PRODUTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO_30 { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1 Execute(R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1 r1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}