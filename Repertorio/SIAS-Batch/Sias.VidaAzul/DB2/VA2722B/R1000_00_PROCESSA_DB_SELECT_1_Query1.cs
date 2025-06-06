using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2722B
{
    public class R1000_00_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            C.NUM_APOLICE ,
            C.COD_SUBGRUPO ,
            C.NUM_CERTIFICADO ,
            C.COD_CLIENTE ,
            C.OCOREND ,
            C.AGE_COBRANCA ,
            C.DATA_MOVIMENTO ,
            C.SIT_REGISTRO
            INTO
            :PROPOVA-NUM-APOLICE ,
            :PROPOVA-COD-SUBGRUPO ,
            :PROPOVA-NUM-CERTIFICADO ,
            :PROPOVA-COD-CLIENTE ,
            :PROPOVA-OCOREND ,
            :PROPOVA-AGE-COBRANCA ,
            :PROPOVA-DATA-MOVIMENTO ,
            :PROPOVA-SIT-REGISTRO
            FROM
            SEGUROS.SUBGRUPOS_VGAP A,
            SEGUROS.PRODUTOS_VG B,
            SEGUROS.PROPOSTAS_VA C
            WHERE
            B.ORIG_PRODU = 'ESPEC'
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799
            AND C.NUM_APOLICE = A.NUM_APOLICE
            AND C.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND C.DTPROXVEN <> '9999-12-31'
            AND C.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											C.NUM_APOLICE 
							,
											C.COD_SUBGRUPO 
							,
											C.NUM_CERTIFICADO 
							,
											C.COD_CLIENTE 
							,
											C.OCOREND 
							,
											C.AGE_COBRANCA 
							,
											C.DATA_MOVIMENTO 
							,
											C.SIT_REGISTRO
											FROM
											SEGUROS.SUBGRUPOS_VGAP A
							,
											SEGUROS.PRODUTOS_VG B
							,
											SEGUROS.PROPOSTAS_VA C
											WHERE
											B.ORIG_PRODU = 'ESPEC'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799
											AND C.NUM_APOLICE = A.NUM_APOLICE
											AND C.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND C.DTPROXVEN <> '9999-12-31'
											AND C.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_DATA_MOVIMENTO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }

        public static R1000_00_PROCESSA_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_DB_SELECT_1_Query1 r1000_00_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}