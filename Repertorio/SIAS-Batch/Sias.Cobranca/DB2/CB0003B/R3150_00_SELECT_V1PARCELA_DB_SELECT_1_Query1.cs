using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NRENDOS
            ,NRPARCEL
            ,DACPARC
            ,FONTE
            ,NRTIT
            ,PRM_TARIFARIO_IX
            ,VAL_DESCONTO_IX
            ,OTNPRLIQ
            ,OTNADFRA
            ,OTNCUSTO
            ,OTNIOF
            ,OTNTOTAL
            ,OCORHIST
            ,QTDDOC
            ,SITUACAO
            INTO :V1PARC-NUM-APOL
            ,:V1PARC-NRENDOS
            ,:V1PARC-NRPARCEL
            ,:V1PARC-DACPARC
            ,:V1PARC-FONTE
            ,:V1PARC-NRTIT
            ,:V1PARC-PRM-TAR
            ,:V1PARC-VAL-DES
            ,:V1PARC-OTNPRLIQ
            ,:V1PARC-OTNADFRA
            ,:V1PARC-OTNCUSTO
            ,:V1PARC-OTNIOF
            ,:V1PARC-OTNTOTAL
            ,:V1PARC-OCORHIST
            ,:V1PARC-QTDDOC
            ,:V1PARC-SITUACAO
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V1MCOB-NUM-APOL
            AND NRENDOS = :V1MCOB-NRENDOS
            AND NRPARCEL = :V1MCOB-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NRENDOS
											,NRPARCEL
											,DACPARC
											,FONTE
											,NRTIT
											,PRM_TARIFARIO_IX
											,VAL_DESCONTO_IX
											,OTNPRLIQ
											,OTNADFRA
											,OTNCUSTO
											,OTNIOF
											,OTNTOTAL
											,OCORHIST
											,QTDDOC
											,SITUACAO
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V1MCOB_NUM_APOL}'
											AND NRENDOS = '{this.V1MCOB_NRENDOS}'
											AND NRPARCEL = '{this.V1MCOB_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_DACPARC { get; set; }
        public string V1PARC_FONTE { get; set; }
        public string V1PARC_NRTIT { get; set; }
        public string V1PARC_PRM_TAR { get; set; }
        public string V1PARC_VAL_DES { get; set; }
        public string V1PARC_OTNPRLIQ { get; set; }
        public string V1PARC_OTNADFRA { get; set; }
        public string V1PARC_OTNCUSTO { get; set; }
        public string V1PARC_OTNIOF { get; set; }
        public string V1PARC_OTNTOTAL { get; set; }
        public string V1PARC_OCORHIST { get; set; }
        public string V1PARC_QTDDOC { get; set; }
        public string V1PARC_SITUACAO { get; set; }
        public string V1MCOB_NUM_APOL { get; set; }
        public string V1MCOB_NRPARCEL { get; set; }
        public string V1MCOB_NRENDOS { get; set; }

        public static R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 Execute(R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 r3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3150_00_SELECT_V1PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1PARC_DACPARC = result[i++].Value?.ToString();
            dta.V1PARC_FONTE = result[i++].Value?.ToString();
            dta.V1PARC_NRTIT = result[i++].Value?.ToString();
            dta.V1PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V1PARC_VAL_DES = result[i++].Value?.ToString();
            dta.V1PARC_OTNPRLIQ = result[i++].Value?.ToString();
            dta.V1PARC_OTNADFRA = result[i++].Value?.ToString();
            dta.V1PARC_OTNCUSTO = result[i++].Value?.ToString();
            dta.V1PARC_OTNIOF = result[i++].Value?.ToString();
            dta.V1PARC_OTNTOTAL = result[i++].Value?.ToString();
            dta.V1PARC_OCORHIST = result[i++].Value?.ToString();
            dta.V1PARC_QTDDOC = result[i++].Value?.ToString();
            dta.V1PARC_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}