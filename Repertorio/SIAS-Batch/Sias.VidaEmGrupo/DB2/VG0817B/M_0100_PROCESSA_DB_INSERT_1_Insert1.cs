using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0817B
{
    public class M_0100_PROCESSA_DB_INSERT_1_Insert1 : QueryBasis<M_0100_PROCESSA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VG0817B' ,
            :V0SIST-DTMOVABE,
            'VG' ,
            'VG9574B' ,
            0,
            0,
            :V0RELA-PERI-INICIAL,
            :V0RELA-PERI-FINAL,
            :V0RELA-PERI-INICIAL,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0PROP-NUM-APOLICE,
            0,
            :V0HCOB-NRPARCEL,
            :V0HCOB-NRCERTIF,
            :V0HCOB-NRTIT,
            :V0PROP-CODSUBES,
            1201,
            9999,
            :V0HCOB-NRPARCEL,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            :V0SUBG-TIPO-FATURAMENTO,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            :V0SUBG-PERI-FATURAMENTO,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0817B' , {FieldThreatment(this.V0SIST_DTMOVABE)}, 'VG' , 'VG9574B' , 0, 0, {FieldThreatment(this.V0RELA_PERI_INICIAL)}, {FieldThreatment(this.V0RELA_PERI_FINAL)}, {FieldThreatment(this.V0RELA_PERI_INICIAL)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0PROP_NUM_APOLICE)}, 0, {FieldThreatment(this.V0HCOB_NRPARCEL)}, {FieldThreatment(this.V0HCOB_NRCERTIF)}, {FieldThreatment(this.V0HCOB_NRTIT)}, {FieldThreatment(this.V0PROP_CODSUBES)}, 1201, 9999, {FieldThreatment(this.V0HCOB_NRPARCEL)}, ' ' , ' ' , 0, 0, ' ' , 0, 0, {FieldThreatment(this.V0SUBG_TIPO_FATURAMENTO)}, '0' , ' ' , ' ' , NULL, {FieldThreatment(this.V0SUBG_PERI_FATURAMENTO)}, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0RELA_PERI_INICIAL { get; set; }
        public string V0RELA_PERI_FINAL { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0SUBG_TIPO_FATURAMENTO { get; set; }
        public string V0SUBG_PERI_FATURAMENTO { get; set; }

        public static void Execute(M_0100_PROCESSA_DB_INSERT_1_Insert1 m_0100_PROCESSA_DB_INSERT_1_Insert1)
        {
            var ths = m_0100_PROCESSA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_PROCESSA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}