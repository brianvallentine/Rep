using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2139B
{
    public class R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES (:V0RELA-CODUSU,
            :V0RELA-DATA-SOLICITACAO,
            :V0RELA-IDSISTEM,
            :V0RELA-CODRELAT,
            :V0RELA-NRCOPIAS,
            :V0RELA-QUANTIDADE,
            :V0RELA-PERI-INICIAL,
            :V0RELA-PERI-FINAL,
            :V0RELA-DATA-REFERENCIA,
            :V0RELA-MES-REFERENCIA,
            :V0RELA-ANO-REFERENCIA,
            :V0RELA-ORGAO,
            :V0RELA-FONTE,
            :V0RELA-CODPDT,
            :V0RELA-RAMO,
            :V0RELA-MODALIDA,
            :V0RELA-CONGENER,
            :V0RELA-NUM-APOLICE,
            :V0RELA-NRENDOS,
            :V0RELA-NRPARCEL,
            :V0RELA-NRCERTIF,
            :V0RELA-NRTIT,
            :V0RELA-CODSUBES,
            :V0RELA-OPERACAO,
            :V0RELA-COD-PLANO,
            :V0RELA-OCORHIST,
            :V0RELA-APOLIDER,
            :V0RELA-ENDOSLID,
            :V0RELA-NUM-PARC-LIDER,
            :V0RELA-NUM-SINISTRO,
            :V0RELA-NUM-SINI-LIDER,
            :V0RELA-NUM-ORDEM,
            :V0RELA-CODUNIMO,
            :V0RELA-CORRECAO,
            :V0RELA-SITUACAO,
            :V0RELA-PREVIA-DEFINITIVA,
            :V0RELA-ANAL-RESUMO,
            :V0RELA-COD-EMPRESA,
            :V0RELA-PERI-RENOVACAO,
            :V0RELA-PCT-AUMENTO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ({FieldThreatment(this.V0RELA_CODUSU)}, {FieldThreatment(this.V0RELA_DATA_SOLICITACAO)}, {FieldThreatment(this.V0RELA_IDSISTEM)}, {FieldThreatment(this.V0RELA_CODRELAT)}, {FieldThreatment(this.V0RELA_NRCOPIAS)}, {FieldThreatment(this.V0RELA_QUANTIDADE)}, {FieldThreatment(this.V0RELA_PERI_INICIAL)}, {FieldThreatment(this.V0RELA_PERI_FINAL)}, {FieldThreatment(this.V0RELA_DATA_REFERENCIA)}, {FieldThreatment(this.V0RELA_MES_REFERENCIA)}, {FieldThreatment(this.V0RELA_ANO_REFERENCIA)}, {FieldThreatment(this.V0RELA_ORGAO)}, {FieldThreatment(this.V0RELA_FONTE)}, {FieldThreatment(this.V0RELA_CODPDT)}, {FieldThreatment(this.V0RELA_RAMO)}, {FieldThreatment(this.V0RELA_MODALIDA)}, {FieldThreatment(this.V0RELA_CONGENER)}, {FieldThreatment(this.V0RELA_NUM_APOLICE)}, {FieldThreatment(this.V0RELA_NRENDOS)}, {FieldThreatment(this.V0RELA_NRPARCEL)}, {FieldThreatment(this.V0RELA_NRCERTIF)}, {FieldThreatment(this.V0RELA_NRTIT)}, {FieldThreatment(this.V0RELA_CODSUBES)}, {FieldThreatment(this.V0RELA_OPERACAO)}, {FieldThreatment(this.V0RELA_COD_PLANO)}, {FieldThreatment(this.V0RELA_OCORHIST)}, {FieldThreatment(this.V0RELA_APOLIDER)}, {FieldThreatment(this.V0RELA_ENDOSLID)}, {FieldThreatment(this.V0RELA_NUM_PARC_LIDER)}, {FieldThreatment(this.V0RELA_NUM_SINISTRO)}, {FieldThreatment(this.V0RELA_NUM_SINI_LIDER)}, {FieldThreatment(this.V0RELA_NUM_ORDEM)}, {FieldThreatment(this.V0RELA_CODUNIMO)}, {FieldThreatment(this.V0RELA_CORRECAO)}, {FieldThreatment(this.V0RELA_SITUACAO)}, {FieldThreatment(this.V0RELA_PREVIA_DEFINITIVA)}, {FieldThreatment(this.V0RELA_ANAL_RESUMO)}, {FieldThreatment(this.V0RELA_COD_EMPRESA)}, {FieldThreatment(this.V0RELA_PERI_RENOVACAO)}, {FieldThreatment(this.V0RELA_PCT_AUMENTO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RELA_CODUSU { get; set; }
        public string V0RELA_DATA_SOLICITACAO { get; set; }
        public string V0RELA_IDSISTEM { get; set; }
        public string V0RELA_CODRELAT { get; set; }
        public string V0RELA_NRCOPIAS { get; set; }
        public string V0RELA_QUANTIDADE { get; set; }
        public string V0RELA_PERI_INICIAL { get; set; }
        public string V0RELA_PERI_FINAL { get; set; }
        public string V0RELA_DATA_REFERENCIA { get; set; }
        public string V0RELA_MES_REFERENCIA { get; set; }
        public string V0RELA_ANO_REFERENCIA { get; set; }
        public string V0RELA_ORGAO { get; set; }
        public string V0RELA_FONTE { get; set; }
        public string V0RELA_CODPDT { get; set; }
        public string V0RELA_RAMO { get; set; }
        public string V0RELA_MODALIDA { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_NUM_APOLICE { get; set; }
        public string V0RELA_NRENDOS { get; set; }
        public string V0RELA_NRPARCEL { get; set; }
        public string V0RELA_NRCERTIF { get; set; }
        public string V0RELA_NRTIT { get; set; }
        public string V0RELA_CODSUBES { get; set; }
        public string V0RELA_OPERACAO { get; set; }
        public string V0RELA_COD_PLANO { get; set; }
        public string V0RELA_OCORHIST { get; set; }
        public string V0RELA_APOLIDER { get; set; }
        public string V0RELA_ENDOSLID { get; set; }
        public string V0RELA_NUM_PARC_LIDER { get; set; }
        public string V0RELA_NUM_SINISTRO { get; set; }
        public string V0RELA_NUM_SINI_LIDER { get; set; }
        public string V0RELA_NUM_ORDEM { get; set; }
        public string V0RELA_CODUNIMO { get; set; }
        public string V0RELA_CORRECAO { get; set; }
        public string V0RELA_SITUACAO { get; set; }
        public string V0RELA_PREVIA_DEFINITIVA { get; set; }
        public string V0RELA_ANAL_RESUMO { get; set; }
        public string V0RELA_COD_EMPRESA { get; set; }
        public string V0RELA_PERI_RENOVACAO { get; set; }
        public string V0RELA_PCT_AUMENTO { get; set; }

        public static void Execute(R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 r4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4600_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}