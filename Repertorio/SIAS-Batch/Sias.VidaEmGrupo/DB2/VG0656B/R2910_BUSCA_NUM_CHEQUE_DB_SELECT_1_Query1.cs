using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1 : QueryBasis<R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CHEQUE_INTERNO ,
            DIG_CHEQUE_INTERNO
            INTO :CBCONDEV-NUM-CHEQUE-INTERNO ,
            :CBCONDEV-DIG-CHEQUE-INTERNO
            FROM SEGUROS.CB_CONTR_DEVPREMIO
            WHERE TIPO_MOVIMENTO = '8'
            AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CHEQUE_INTERNO 
							,
											DIG_CHEQUE_INTERNO
											FROM SEGUROS.CB_CONTR_DEVPREMIO
											WHERE TIPO_MOVIMENTO = '8'
											AND NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string CBCONDEV_NUM_CHEQUE_INTERNO { get; set; }
        public string CBCONDEV_DIG_CHEQUE_INTERNO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1 Execute(R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1 r2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBCONDEV_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.CBCONDEV_DIG_CHEQUE_INTERNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}