using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1 : QueryBasis<R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.QTTITCAP ,
            A.VLTITCAP ,
            A.VLCUSTCAP ,
            B.COD_RUBRICA
            INTO :PLAVAVGA-QTTITCAP ,
            :PLAVAVGA-VLTITCAP ,
            :PLAVAVGA-VLCUSTCAP,
            :PRODUVG-COD-RUBRICA
            FROM SEGUROS.PLANOS_VA_VGAP A,
            SEGUROS.PRODUTOS_VG B
            WHERE A.NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND A.CODSUBES = 0
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.CODSUBES = B.COD_SUBGRUPO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.QTTITCAP 
							,
											A.VLTITCAP 
							,
											A.VLCUSTCAP 
							,
											B.COD_RUBRICA
											FROM SEGUROS.PLANOS_VA_VGAP A
							,
											SEGUROS.PRODUTOS_VG B
											WHERE A.NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND A.CODSUBES = 0
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.CODSUBES = B.COD_SUBGRUPO";

            return query;
        }
        public string PLAVAVGA_QTTITCAP { get; set; }
        public string PLAVAVGA_VLTITCAP { get; set; }
        public string PLAVAVGA_VLCUSTCAP { get; set; }
        public string PRODUVG_COD_RUBRICA { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1 Execute(R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1 r4250_00_SELECT_PLANVG_DB_SELECT_1_Query1)
        {
            var ths = r4250_00_SELECT_PLANVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4250_00_SELECT_PLANVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLAVAVGA_QTTITCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLTITCAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_VLCUSTCAP = result[i++].Value?.ToString();
            dta.PRODUVG_COD_RUBRICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}