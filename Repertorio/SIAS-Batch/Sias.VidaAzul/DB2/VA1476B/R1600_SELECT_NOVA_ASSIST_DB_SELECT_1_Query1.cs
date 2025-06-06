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
    public class R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1 : QueryBasis<R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CASE T2.COD_COBERTURA
            WHEN 16 THEN '40000527293'
            WHEN 81 THEN '40000999981'
            WHEN 83 THEN '40000527273'
            WHEN 84 THEN '40000527275'
            WHEN 85 THEN '40000527277'
            WHEN 86 THEN '40000527305'
            WHEN 87 THEN '40000527279'
            WHEN 88 THEN '40000527281'
            WHEN 89 THEN '40000527283'
            WHEN 90 THEN '40000527285'
            WHEN 91 THEN '40000527287'
            WHEN 92 THEN '40000527307'
            WHEN 88 THEN '40000527289'
            WHEN 2 THEN '40000142243'
            WHEN 93 THEN '40000528999'
            WHEN 94 THEN '40000529003'
            WHEN 95 THEN '40000529001'
            WHEN 96 THEN '40000529005'
            WHEN 97 THEN '40000529007'
            WHEN 24 THEN '40000042589'
            END AS CONVENIO
            ,T2.COD_COBERTURA
            INTO
            :WHOST-COD-CONVENIO
            ,:VGCOBSUB-COD-COBERTURA
            FROM
            SEGUROS.PRODUTOS_VG AS T1
            ,SEGUROS.VG_COBERTURAS_SUBG AS T2
            ,SEGUROS.VG_ACESSORIO AS T3
            ,SEGUROS.VG_PLANO_SUBGRUPO AS T4
            ,SEGUROS.PROPOSTAS_VA AS T5
            WHERE
            T1.NUM_APOLICE = T2.NUM_APOLICE
            AND
            T2.COD_COBERTURA = T3.NUM_ACESSORIO
            AND
            T1.COD_SUBGRUPO = T2.COD_SUBGRUPO
            AND
            T1.NUM_APOLICE = T4.NUM_APOLICE
            AND
            T1.COD_SUBGRUPO = T4.COD_SUBGRUPO
            AND
            T1.NUM_APOLICE = T5.NUM_APOLICE
            AND
            T1.COD_SUBGRUPO = T5.COD_SUBGRUPO
            AND
            T4.COD_OPCAO_COBER = T5.OPCAO_COBERTURA
            AND
            T4.STA_REGISTRO = 0
            AND
            T2.SIT_COBERTURA = '0'
            AND
            T4.COD_TIPO_ASSISTENCIA IN (1,2,3)
            AND
            T5.NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO
            AND
            T2.COD_COBERTURA = :VGCOBSUB-COD-COBERTURA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CASE T2.COD_COBERTURA
											WHEN 16 THEN '40000527293'
											WHEN 81 THEN '40000999981'
											WHEN 83 THEN '40000527273'
											WHEN 84 THEN '40000527275'
											WHEN 85 THEN '40000527277'
											WHEN 86 THEN '40000527305'
											WHEN 87 THEN '40000527279'
											WHEN 88 THEN '40000527281'
											WHEN 89 THEN '40000527283'
											WHEN 90 THEN '40000527285'
											WHEN 91 THEN '40000527287'
											WHEN 92 THEN '40000527307'
											WHEN 88 THEN '40000527289'
											WHEN 2 THEN '40000142243'
											WHEN 93 THEN '40000528999'
											WHEN 94 THEN '40000529003'
											WHEN 95 THEN '40000529001'
											WHEN 96 THEN '40000529005'
											WHEN 97 THEN '40000529007'
											WHEN 24 THEN '40000042589'
											END AS CONVENIO
											,T2.COD_COBERTURA
											FROM
											SEGUROS.PRODUTOS_VG AS T1
											,SEGUROS.VG_COBERTURAS_SUBG AS T2
											,SEGUROS.VG_ACESSORIO AS T3
											,SEGUROS.VG_PLANO_SUBGRUPO AS T4
											,SEGUROS.PROPOSTAS_VA AS T5
											WHERE
											T1.NUM_APOLICE = T2.NUM_APOLICE
											AND
											T2.COD_COBERTURA = T3.NUM_ACESSORIO
											AND
											T1.COD_SUBGRUPO = T2.COD_SUBGRUPO
											AND
											T1.NUM_APOLICE = T4.NUM_APOLICE
											AND
											T1.COD_SUBGRUPO = T4.COD_SUBGRUPO
											AND
											T1.NUM_APOLICE = T5.NUM_APOLICE
											AND
											T1.COD_SUBGRUPO = T5.COD_SUBGRUPO
											AND
											T4.COD_OPCAO_COBER = T5.OPCAO_COBERTURA
											AND
											T4.STA_REGISTRO = 0
											AND
											T2.SIT_COBERTURA = '0'
											AND
											T4.COD_TIPO_ASSISTENCIA IN (1
							,2
							,3)
											AND
											T5.NUM_CERTIFICADO = '{this.MOVIMVGA_NUM_CERTIFICADO}'
											AND
											T2.COD_COBERTURA = '{this.VGCOBSUB_COD_COBERTURA}'
											WITH UR";

            return query;
        }
        public string WHOST_COD_CONVENIO { get; set; }
        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }

        public static R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1 Execute(R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1 r1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1)
        {
            var ths = r1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COD_CONVENIO = result[i++].Value?.ToString();
            dta.VGCOBSUB_COD_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}