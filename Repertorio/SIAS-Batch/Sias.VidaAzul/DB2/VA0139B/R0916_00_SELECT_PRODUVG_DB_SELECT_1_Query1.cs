using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ESTR_COBR,
            CODPRODU
            INTO :V0PRVG-ESTR-COBR ,
            :V0PRVG-CODPRODU
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE
            AND CODSUBES = :V0HCTB-CODSUBES
            AND DIA_FATURA = 31
            AND ESTR_COBR IN ( 'MULT' , 'FEDERAL' )
            AND ORIG_PRODU NOT IN ( 'EMPRE' , 'ESPEC' ,
            'ESPE1' , 'ESPE2' ,
            'ESPE3' , 'ESPE4' ,
            'ESPE5' , 'ESPE6' ,
            'GLOBAL' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ESTR_COBR
							,
											CODPRODU
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.V0HCTB_NUM_APOLICE}'
											AND CODSUBES = '{this.V0HCTB_CODSUBES}'
											AND DIA_FATURA = 31
											AND ESTR_COBR IN ( 'MULT' 
							, 'FEDERAL' )
											AND ORIG_PRODU NOT IN ( 'EMPRE' 
							, 'ESPEC' 
							,
											'ESPE1' 
							, 'ESPE2' 
							,
											'ESPE3' 
							, 'ESPE4' 
							,
											'ESPE5' 
							, 'ESPE6' 
							,
											'GLOBAL' )";

            return query;
        }
        public string V0PRVG_ESTR_COBR { get; set; }
        public string V0PRVG_CODPRODU { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0HCTB_CODSUBES { get; set; }

        public static R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRVG_ESTR_COBR = result[i++].Value?.ToString();
            dta.V0PRVG_CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}