using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0055B
{
    public class R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.COD_SUBGRUPO,
            VALUE(A.COD_USUARIO, 'VA0601B' )
            INTO :PROPOVA-NUM-APOLICE ,
            :PROPOVA-COD-SUBGRUPO,
            :PROPOVA-COD-USUARIO
            FROM SEGUROS.PROPOSTAS_VA A,
            SEGUROS.HIS_COBER_PROPOST B
            WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND A.SIT_REGISTRO IN ( 'E' , '9' )
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND B.DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.COD_SUBGRUPO
							,
											VALUE(A.COD_USUARIO
							, 'VA0601B' )
											FROM SEGUROS.PROPOSTAS_VA A
							,
											SEGUROS.HIS_COBER_PROPOST B
											WHERE A.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND A.SIT_REGISTRO IN ( 'E' 
							, '9' )
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND B.DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_COD_USUARIO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1 r1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}