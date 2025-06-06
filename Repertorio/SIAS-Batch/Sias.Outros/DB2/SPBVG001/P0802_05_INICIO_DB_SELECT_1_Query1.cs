using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0802_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0802_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PV001.NUM_CERTIFICADO
            ,CL001.CGCCPF
            ,HC001.IMPSEGUR
            ,HC001.VLPREMIO
            ,PV001.DTINCLUS
            ,PV001.DATA_QUITACAO
            INTO :VG103-NUM-CERTIFICADO
            ,:VG103-NUM-CPF-CNPJ
            ,:VG103-VLR-IS
            ,:VG103-VLR-PREMIO
            ,:VG103-DTA-OCORRENCIA
            ,:VG103-DTA-RCAP
            FROM SEGUROS.HIS_COBER_PROPOST HC001
            ,SEGUROS.CLIENTES CL001
            ,SEGUROS.PROPOSTAS_VA PV001
            WHERE PV001.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO
            AND HC001.NUM_CERTIFICADO = PV001.NUM_CERTIFICADO
            AND CL001.COD_CLIENTE = PV001.COD_CLIENTE
            AND HC001.DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PV001.NUM_CERTIFICADO
											,CL001.CGCCPF
											,HC001.IMPSEGUR
											,HC001.VLPREMIO
											,PV001.DTINCLUS
											,PV001.DATA_QUITACAO
											FROM SEGUROS.HIS_COBER_PROPOST HC001
											,SEGUROS.CLIENTES CL001
											,SEGUROS.PROPOSTAS_VA PV001
											WHERE PV001.NUM_CERTIFICADO = '{this.VG103_NUM_CERTIFICADO}'
											AND HC001.NUM_CERTIFICADO = PV001.NUM_CERTIFICADO
											AND CL001.COD_CLIENTE = PV001.COD_CLIENTE
											AND HC001.DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_NUM_CPF_CNPJ { get; set; }
        public string VG103_VLR_IS { get; set; }
        public string VG103_VLR_PREMIO { get; set; }
        public string VG103_DTA_OCORRENCIA { get; set; }
        public string VG103_DTA_RCAP { get; set; }

        public static P0802_05_INICIO_DB_SELECT_1_Query1 Execute(P0802_05_INICIO_DB_SELECT_1_Query1 p0802_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0802_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0802_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0802_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG103_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG103_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.VG103_VLR_IS = result[i++].Value?.ToString();
            dta.VG103_VLR_PREMIO = result[i++].Value?.ToString();
            dta.VG103_DTA_OCORRENCIA = result[i++].Value?.ToString();
            dta.VG103_DTA_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}