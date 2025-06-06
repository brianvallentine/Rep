using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1466B
{
    public class R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO,
            A.COD_MSG_CRITICA
            INTO :BILHEERR-NUM-BILHETE,
            :BILHEERR-COD-ERRO
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :V0PROP-NUMBIL
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
            AND B.COD_TP_MSG_CRITICA <> '3'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
							,
											A.COD_MSG_CRITICA
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.V0PROP_NUMBIL}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
											AND B.COD_TP_MSG_CRITICA <> '3'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string BILHEERR_NUM_BILHETE { get; set; }
        public string BILHEERR_COD_ERRO { get; set; }
        public string V0PROP_NUMBIL { get; set; }

        public static R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1 r1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHEERR_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHEERR_COD_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}