using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 : QueryBasis<R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1>
    {

        private VG0853B_CPROPVA CurrentOf { get; set; }

        public R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1(VG0853B_CPROPVA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET NRPARCE =  '{this.V0PROP_NRPARCEL}',
				SITUACAO =  '{this.V0PROP_SITUACAO}',
				DTVENCTO =  '{this.V0PROP_DTVENCTO}',
				DTPROXVEN =  '{this.V0PROP_DTPROXVEN}',
				NRPRIPARATZ =  '{this.V0PROP_NRPRIPARATZ}',
				QTDPARATZ =  '{this.V0PROP_QTDPARATZ}',
				OCORHIST =  '{this.V0PROP_OCORHIST}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE
				(
					DTPROXVEN BETWEEN '{this.WHOST_MIN_DTPROXVEN}' AND '{this.V1SIST_DT_23_CYRELA}' AND SITUACAO IN ( '3', '6' ) AND NUM_APOLICE NOT IN (109300000635, 108208503665, 109300006385, 107700000007) AND CODPRODU IN (7701, 7703, 8203, '{this.JVPRD8203}', 8205, '{this.JVPRD8205}', 8206, '{this.JVPRD8206}', 8207, 8209, '{this.JVPRD8209}', 8214, '{this.JVPRD8214}', 8215, 8217, 8220, 8222, 8223, 8224, 8225, 8226, 8228, 8234, 9306, 9311, '{this.JVPRD9311}', 9313, 9315, 9316, 9322, 9323, 9324, 9325, 9326, 9329, '{this.JVPRD9329}', 9330, '{this.JVPRD9330}', 9331, 9343, '{this.JVPRD9343}', 9354, 9363, 9365, 9706, 9711, 9712, 9713, 9714, 9715 ) AND DTPROXVEN <> '9999-12-31'
				)
				AND OCORHIST {FieldThreatment(CurrentOf.V0PROP_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string V0PROP_NRPRIPARATZ { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0PROP_OCORHIST { get; set; }
        public string WHOST_MIN_DTPROXVEN { get; set; }
        public string V1SIST_DT_23_CYRELA { get; set; }
        public string JVPRD8203 { get; set; }
        public string JVPRD8205 { get; set; }
        public string JVPRD8206 { get; set; }
        public string JVPRD8209 { get; set; }
        public string JVPRD8214 { get; set; }
        public string JVPRD9311 { get; set; }
        public string JVPRD9329 { get; set; }
        public string JVPRD9330 { get; set; }
        public string JVPRD9343 { get; set; }

        public static void Execute(R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1)
        {
            var ths = r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}